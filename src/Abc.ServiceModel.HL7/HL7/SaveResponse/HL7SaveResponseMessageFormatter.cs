﻿namespace Abc.ServiceModel.HL7
{
    using Abc.ServiceModel.Protocol.HL7;
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// HL7 message formmater.
    /// </summary>
    public partial class HL7SaveResponseMessageFormatter : IClientMessageFormatter
    {
        private HL7SaveResponseOperationContractAttribute attribute;
        private Type inputSerializerType;
        private Type outputParameterType;
        private Type outputSerializerType;
        private Type parameterType;

        // private HL7Request.RequestType queryRequest;
        private string version;

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7SaveResponseMessageFormatter"/> class.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="parameterType">Type of the parameter.</param>
        /// <param name="outputParameterType">Type of the output parameter.</param>
        /// <param name="inputSerializerType">Type of the input serializer.</param>
        /// <param name="outputSerializerType">Type of the output serializer.</param>
        internal HL7SaveResponseMessageFormatter(HL7SaveResponseOperationContractAttribute attribute, Type parameterType, Type outputParameterType, Type inputSerializerType, Type outputSerializerType)
        {
            this.parameterType = parameterType;
            this.outputParameterType = outputParameterType;
            this.inputSerializerType = inputSerializerType;
            this.outputSerializerType = outputSerializerType;
            this.attribute = attribute;

            // this.queryRequest = HL7Request.RequestType.MessageRequest;
            switch (attribute.Version)
            {
                case HL7Constants.Versions.HL7Version.HL72006:
                    this.version = HL7Constants.Versions.V3NE2006;
                    break;

                case HL7Constants.Versions.HL7Version.HL72011:
                    this.version = HL7Constants.Versions.V3NE2011;
                    break;

                default:
                    this.version = HL7Constants.Versions.V3NE2011;
                    break;
            }
        }

        /// <summary>
        /// Converts a message into a return value and out parameters that are passed back to the calling operation.
        /// </summary>
        /// <param name="message">The inbound message.</param>
        /// <param name="parameters">Any out values.</param>
        /// <returns>
        /// The return value of the operation.
        /// </returns>
        public object DeserializeReply(Message message, object[] parameters)
        {
            if (message == null) {  throw new ArgumentNullException("message", "message != null"); }

            object body = null;

            // Set operation Context
            if (!message.IsFault)
            {
                string interactionId = this.attribute.ReplyInteraction;

                // string templateId = this.attribute.ReplyTemplate;
                var messageHl7 = message.ReadHL7Message(interactionId);

                // Generate HL7 Fault Exception
                if (messageHl7.Acknowledgement != null)
                {
                    if (messageHl7.Acknowledgement.AcknowledgementDataType != HL7AcknowledgementType.AcceptAcknowledgementCommitAccept
                        && messageHl7.Acknowledgement.AcknowledgementDataType != HL7AcknowledgementType.ApplicationAcknowledgementAccept)
                    {
                        throw new HL7FaultException(messageHl7.Acknowledgement.AcknowledgementDetails, null);
                    }
                }

                if (this.attribute != null && !this.attribute.AcknowledgementResponse && this.parameterType != typeof(void))
                {
                    body = messageHl7.ControlAct.Subject.GetBody(this.CreateInputSerializer(this.parameterType, HL7Request.RequestType.MessageRequest));
                }

                var operationContext = new HL7OperationContext();
                operationContext.OperationSaveContract = this.attribute;

                if (OperationContext.Current != null)
                {
                    OperationContext.Current.Extensions.Add(operationContext);

                    if (messageHl7 != null)
                    {
                        operationContext.MessageId = messageHl7.IdentificationId.Extension;
                        operationContext.Sender = messageHl7.Sender;
                        operationContext.Receiver = messageHl7.Receiver;
                        operationContext.TargetMessage = messageHl7.Acknowledgement.TargetMessage.Extension;
                        operationContext.CreationTime = messageHl7.CreationTime;

                        if (messageHl7.Acknowledgement != null)
                        {
                            operationContext.AcknowledgementType = messageHl7.Acknowledgement.AcknowledgementDataType;

                            if (messageHl7.Acknowledgement.AcknowledgementDetails != null)
                            {
                                operationContext.AcknowledgementDetail = messageHl7.Acknowledgement.AcknowledgementDetails;
                            }
                        }
                    }
                }
            }

            return body;
        }

        /// <summary>
        /// Converts an <see cref="T:System.Object"/> array into an outbound <see cref="T:System.ServiceModel.Channels.Message"/>.
        /// </summary>
        /// <param name="messageVersion">The version of the SOAP message to use.</param>
        /// <param name="parameters">The parameters passed to the  client operation.</param>
        /// <returns>
        /// The SOAP message sent to the service operation.
        /// </returns>
        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            if (parameters == null) {  throw new ArgumentNullException("parameters", "parameters != null"); }
            if (!(parameters.Length > 0)) {  throw new ArgumentException("parameters", "parameters.Length > 0"); }
            if (!(parameters.Length <= 4)) {  throw new ArgumentException("parameters", "parameters.Length <= 4"); }

            string interactionId = this.attribute.Interaction;

            // UrnType templateId = new UrnType(this.attribute.Template);
            // string deviceSender = this.attribute.Sender;
            // string deviceReceiver = this.attribute.Receiver;
            HL7ControlAct controlAct = parameters[0] as HL7ControlAct;

            // if (controlAct != null)
            // {
            //    controlAct = (HL7ControlAct)parameters[0];
            // }
            // else
            // {
            //    // throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, SrProtocol.IsNotSet, "controlAct"));
            // }
            string receiverExtension = string.Empty;

            if (parameters.Length > 1 && parameters[1] != null && (parameters[1] is string))
            {
                receiverExtension = (string)parameters[1];
            }
            else
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, SrProtocol.IsNotSet, "receiverExtension"));
            }

            HL7Acknowledgement acknowledgementDetail = null;

            if (parameters.Length > 2 && parameters[2] != null)
            {
                if (parameters[2] is HL7Acknowledgement)
                {
                    acknowledgementDetail = (HL7Acknowledgement)parameters[2];
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, SrProtocol.IsNotSet, "acknowledgementDetail"));
                }
            }

            this.attribute.Receiver = receiverExtension;
            HL7Device sender = new HL7Device(this.attribute.Sender, HL7Constants.AttributesValue.Sender);
            HL7Device receiver = new HL7Device(this.attribute.Receiver, HL7Constants.AttributesValue.Receiver);
            HL7TransmissionWrapper response;
            response = this.CreateResponse(interactionId, receiver, sender, acknowledgementDetail, controlAct);

            // }
            // else
            // {
            //    if (!(controlAct is string))
            //    {
            //        response = CreateMessageResponse(interactionId, receiver, sender, acknowledgementDetail, controlAct);
            //    }
            //    else
            //    {
            //        response = CreateMessageResponse(interactionId, receiver, sender, acknowledgementDetail);
            //    }
            // }
            if (response == null || response.Acknowledgement == null || response.Acknowledgement.TargetMessage == null || response.Acknowledgement.TargetMessage.Extension == null)
            {
                throw new ArgumentException("Acknowledgement identification is not set {response.Acknowledgement.TargetMessage.Extension}");
            }

            return HL7MessageExtension.CreateHL7Message(messageVersion, interactionId, response);
        }

        /// <summary>
        /// Creates the serializer.
        /// </summary>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <param name="type">The type.</param>
        /// <returns>XmlObject Serializer</returns>
        private static XmlObjectSerializer CreateSerializer(Type serializerType, Type type)
        {
            if (serializerType != null)
            {
                return HL7SubjectSerializerDefaults.CreateSerializer(serializerType, type);
            }

            return HL7SubjectSerializerDefaults.CreateSerializer(type);
        }

        /// <summary>
        /// Creates the serializer query continuation.
        /// </summary>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <param name="type">The type.</param>
        /// <returns>XmlObject Serializer</returns>
        private static XmlObjectSerializer CreateSerializerQueryContinuation(Type serializerType, Type type)
        {
            if (serializerType != null)
            {
                return HL7QueryContinuationPayloadSerializerDefaults.CreateSerializer(serializerType, type);
            }

            return HL7QueryContinuationPayloadSerializerDefaults.CreateSerializer(type);
        }

        /// <summary>
        /// Creates the serializer query param request.
        /// </summary>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <param name="type">The type.</param>
        /// <returns>XmlObject Serializer</returns>
        private static XmlObjectSerializer CreateSerializerQueryParamRequest(Type serializerType, Type type)
        {
            if (serializerType != null)
            {
                return HL7QueryByParameterPayloadSerializerDefaults.CreateSerializer(serializerType, type);
            }

            return HL7QueryByParameterPayloadSerializerDefaults.CreateSerializer(type);
        }

        [System.Obsolete("obsolte", true)]
        private XmlObjectSerializer CreateInputSerializer(Type type)
        {
            return CreateSerializer(this.inputSerializerType, type);
        }

        private XmlObjectSerializer CreateInputSerializer(Type type, HL7Request.RequestType subject)
        {
            switch (subject)
            {
                case HL7Request.RequestType.MessageRequest:
                    return CreateSerializer(this.inputSerializerType, type);
                case HL7Request.RequestType.QueryParamRequest:
                    return CreateSerializerQueryParamRequest(this.inputSerializerType, type);
                case HL7Request.RequestType.QueryContinuationRequest:
                    return CreateSerializerQueryContinuation(this.outputSerializerType, type);
                default:
                    return CreateSerializer(this.inputSerializerType, type);
            }
        }

        [System.Obsolete("obsolte", true)]
        private XmlObjectSerializer CreateOutputSerializer(Type type)
        {
            return CreateSerializer(this.outputSerializerType, type);
        }

        private XmlObjectSerializer CreateOutputSerializer(Type type, HL7Request.RequestType subject)
        {
            switch (subject)
            {
                case HL7Request.RequestType.MessageRequest:
                    return CreateSerializer(this.outputSerializerType, type);
                case HL7Request.RequestType.QueryParamRequest:
                    return CreateSerializerQueryParamRequest(this.outputSerializerType, type);
                case HL7Request.RequestType.QueryContinuationRequest:
                    return CreateSerializerQueryContinuation(this.outputSerializerType, type);
                default:
                    return CreateSerializer(this.outputSerializerType, type);
            }
        }

        /// <summary>
        /// Creates the message response.
        /// </summary>
        /// <param name="interactionId">The interaction id.</param>
        /// <param name="receiver">The receiver.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="acknowledgementDetail">The acknowledgement detail.</param>
        /// <param name="controlAct">The control act.</param>
        /// <returns>
        /// Message Response
        /// </returns>
        private HL7TransmissionWrapper CreateResponse(string interactionId, HL7Device receiver, HL7Device sender, HL7Acknowledgement acknowledgementDetail, HL7ControlAct controlAct)
        {
            HL7TransmissionWrapper response;

            if (this.attribute.AcknowledgementResponse || this.outputParameterType == typeof(void) || controlAct == null)
            {
                response = new HL7AcknowledgementResponse(interactionId, this.version, receiver.Id.Extension, sender.Id.Extension, acknowledgementDetail);
            }
            else
            {
                response = new HL7ApplicationResponse(interactionId, this.version, receiver.Id.Extension, sender.Id.Extension, controlAct,null, acknowledgementDetail);

                if (controlAct is HL7QueryControlAcknowledgement)
                {
                    return response = new HL7QueryApplicationResponse(interactionId, this.version, receiver.Id.Extension, sender.Id.Extension, controlAct, acknowledgementDetail);
                }

                if (controlAct is HL7MessageControlAct)
                {
                    response = new HL7ApplicationResponse(interactionId, this.version, receiver.Id.Extension, sender.Id.Extension, controlAct, null, acknowledgementDetail);
                }
                else
                {
                    throw new InvalidOperationException("can not create Response");
                }
            }

            return response;
        }

        /// <summary>
        /// Creates the message response.
        /// </summary>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="interactionId">The interaction id.</param>
        /// <param name="receiver">The receiver.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="controlAct">The control act.</param>
        /// <returns>
        /// Message Response
        /// </returns>
        private HL7TransmissionWrapper CreateResponse(HL7OperationContext operationContext, string interactionId, HL7Device receiver, HL7Device sender, HL7ControlAct controlAct)
        {
            HL7TransmissionWrapper response;

            if (this.attribute.AcknowledgementResponse || this.outputParameterType == typeof(void) || controlAct == null)
            {
                return new HL7AcknowledgementResponse(interactionId, this.version, receiver.Id.Extension, sender.Id.Extension, new HL7Acknowledgement(operationContext.MessageId, HL7AcknowledgementType.AcceptAcknowledgementCommitAccept, operationContext.AcknowledgementDetail));
            }
            else
            {
                if (controlAct is HL7QueryControlAcknowledgement)
                {
                    return response = new HL7QueryApplicationResponse(interactionId, this.version, receiver.Id.Extension, sender.Id.Extension, controlAct, new HL7Acknowledgement(operationContext.MessageId, HL7AcknowledgementType.ApplicationAcknowledgementAccept, operationContext.AcknowledgementDetail)); // TODO: constructor with device
                }

                if (controlAct is HL7MessageControlAct)
                {
                    return response = new HL7ApplicationResponse(interactionId, this.version, receiver.Id.Extension, sender.Id.Extension, controlAct,null, new HL7Acknowledgement(operationContext.MessageId, HL7AcknowledgementType.ApplicationAcknowledgementAccept, operationContext.AcknowledgementDetail)); // TODO: constructor with device
                }
                else
                {
                    throw new InvalidOperationException("can not create Response");
                }
            }
        }
    }
}