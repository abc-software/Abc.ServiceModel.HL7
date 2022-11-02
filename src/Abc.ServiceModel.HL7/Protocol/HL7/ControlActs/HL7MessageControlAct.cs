// ----------------------------------------------------------------------------
// <copyright file="HL7MessageControlAct.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

///////////////////////////////////////////////////////////
//  MessageControlAct .cs
//  Implementation of the Class MessageControlAct
//  Generated by Enterprise Architect
//  Created on:      17-okt-2011 19:03:57
//  Original author: Jura
///////////////////////////////////////////////////////////

namespace Abc.ServiceModel.Protocol.HL7
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// HL7 sh�mas klase.  Vad�bas darb�bas (ControlAct) ar biznesa inform�ciju.
    /// </summary>
    public class HL7MessageControlAct : HL7ControlAct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="subject">The subject.</param>
        public HL7MessageControlAct(string action, string reasonCode, HL7Subject subject)
            : base(new HL7ClassificatorId[] { new HL7ClassificatorId(action, HL7Constants.OIds.ActionCodeId), new HL7ClassificatorId(reasonCode, HL7Constants.OIds.ReasonCodeId) }, subject)
        {
            this.DataEnterers = new Collection<HL7DataEnterer>();
            this.AuthorOrPerformers = new Collection<HL7AuthorOrPerformer>();
            this.InformationRecipients = new Collection<HL7InformationRecipient>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="reasonCodes">The reason codes.</param>
        /// <param name="subject">The subject.</param>
        public HL7MessageControlAct(ICollection<HL7ClassificatorId> reasonCodes, HL7Subject subject)
            : base(reasonCodes, subject)
        {
            this.DataEnterers = new Collection<HL7DataEnterer>();
            this.AuthorOrPerformers = new Collection<HL7AuthorOrPerformer>();
            this.InformationRecipients = new Collection<HL7InformationRecipient>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="code">The code. value</param>
        /// <param name="text">The text. value</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="reasonCodes">The reason codes.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject. value</param>
        public HL7MessageControlAct(HL7ClassificatorId code, string text, HL7ClassificatorId priorityCode, ICollection<HL7ClassificatorId> reasonCodes, HL7ClassificatorId languageCode, HL7Subject subject)
            : this(null, null, null, code, text, priorityCode, reasonCodes, languageCode, subject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="text">The text.</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="action">The action.</param>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject.</param>
        public HL7MessageControlAct(HL7ClassificatorId code, string text, HL7ClassificatorId priorityCode, string action, string reasonCode, HL7ClassificatorId languageCode, HL7Subject subject)
            : this(null, null, null, code, text, priorityCode, new HL7ClassificatorId[] { new HL7ClassificatorId(action, HL7Constants.OIds.ActionCodeId), new HL7ClassificatorId(reasonCode, HL7Constants.OIds.ReasonCodeId) }, languageCode, subject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="dataEnterers">The data enterers.</param>
        /// <param name="authorOrPerformers">The author or performers.</param>
        /// <param name="informationRecipients">The information recipients.</param>
        /// <param name="code">The code.</param>
        /// <param name="text">The text.</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="action">The action.</param>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject.</param>
        public HL7MessageControlAct(IEnumerable<HL7DataEnterer> dataEnterers, IEnumerable<HL7AuthorOrPerformer> authorOrPerformers, ICollection<HL7InformationRecipient> informationRecipients, HL7ClassificatorId code, string text, HL7ClassificatorId priorityCode, string action, string reasonCode, HL7ClassificatorId languageCode, HL7Subject subject)
            : this(dataEnterers, authorOrPerformers, informationRecipients, code, text, null, priorityCode, new HL7ClassificatorId[] { new HL7ClassificatorId(action, HL7Constants.OIds.ActionCodeId), new HL7ClassificatorId(reasonCode, HL7Constants.OIds.ReasonCodeId) }, languageCode, subject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="overseer">The overseer.</param>
        /// <param name="dataEnterers">The data enterers.</param>
        /// <param name="authorOrPerformers">The author or performers.</param>
        /// <param name="informationRecipients">The information recipients.</param>
        /// <param name="code">The code.</param>
        /// <param name="text">The text.</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="action">The action.</param>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject.</param>
        public HL7MessageControlAct(IEnumerable<HL7Overseer> overseer, IEnumerable<HL7DataEnterer> dataEnterers, IEnumerable<HL7AuthorOrPerformer> authorOrPerformers, ICollection<HL7InformationRecipient> informationRecipients, HL7ClassificatorId code, string text, HL7ClassificatorId priorityCode, string action, string reasonCode, HL7ClassificatorId languageCode, HL7Subject subject)
            : this(overseer, dataEnterers, authorOrPerformers, informationRecipients, code, text, null, priorityCode, new HL7ClassificatorId[] { new HL7ClassificatorId(action, HL7Constants.OIds.ActionCodeId), new HL7ClassificatorId(reasonCode, HL7Constants.OIds.ReasonCodeId) }, languageCode, subject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="dataEnterers">The data enterers.</param>
        /// <param name="authorOrPerformers">The author or performers.</param>
        /// <param name="informationRecipients">The information recipients.</param>
        /// <param name="code">The code. value</param>
        /// <param name="text">The text. value</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="reasonCodes">The reason codes.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject. value</param>
        public HL7MessageControlAct(IEnumerable<HL7DataEnterer> dataEnterers, IEnumerable<HL7AuthorOrPerformer> authorOrPerformers, ICollection<HL7InformationRecipient> informationRecipients, HL7ClassificatorId code, string text, HL7ClassificatorId priorityCode, ICollection<HL7ClassificatorId> reasonCodes, HL7ClassificatorId languageCode, HL7Subject subject)
            : this(dataEnterers, authorOrPerformers, informationRecipients, code, text, null, priorityCode, reasonCodes, languageCode, subject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="dataEnterers">The data enterers.</param>
        /// <param name="authorOrPerformers">The author or performers.</param>
        /// <param name="informationRecipients">The information recipients.</param>
        /// <param name="code">The code.</param>
        /// <param name="text">The text.</param>
        /// <param name="effectiveTime">The effective time.</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="action">The action.</param>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject.</param>
        public HL7MessageControlAct(IEnumerable<HL7DataEnterer> dataEnterers, IEnumerable<HL7AuthorOrPerformer> authorOrPerformers, ICollection<HL7InformationRecipient> informationRecipients, HL7ClassificatorId code, string text, DateTime? effectiveTime, HL7ClassificatorId priorityCode, string action, string reasonCode, HL7ClassificatorId languageCode, HL7Subject subject)
            : this(dataEnterers, authorOrPerformers, informationRecipients, code, text, effectiveTime, priorityCode, new HL7ClassificatorId[] { new HL7ClassificatorId(action, HL7Constants.OIds.ActionCodeId), new HL7ClassificatorId(reasonCode, HL7Constants.OIds.ReasonCodeId) }, languageCode, subject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="dataEnterers">The data enterers.</param>
        /// <param name="authorOrPerformers">The author or performers.</param>
        /// <param name="informationRecipients">The information recipients.</param>
        /// <param name="code">The code. value</param>
        /// <param name="text">The text. value</param>
        /// <param name="effectiveTime">The effective time.</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="reasonCodes">The reason code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject. value</param>
        public HL7MessageControlAct(IEnumerable<HL7DataEnterer> dataEnterers, IEnumerable<HL7AuthorOrPerformer> authorOrPerformers, ICollection<HL7InformationRecipient> informationRecipients, HL7ClassificatorId code, string text, DateTime? effectiveTime, HL7ClassificatorId priorityCode, ICollection<HL7ClassificatorId> reasonCodes, HL7ClassificatorId languageCode, HL7Subject subject)
            : base(code, effectiveTime, text, priorityCode, reasonCodes, languageCode, subject)
        {
            this.DataEnterers = new Collection<HL7DataEnterer>();
            this.AuthorOrPerformers = new Collection<HL7AuthorOrPerformer>();
            this.InformationRecipients = new Collection<HL7InformationRecipient>();
            this.ReasonCodes = reasonCodes;

            if (dataEnterers != null)
            {
                foreach (var item in dataEnterers)
                {
                    if (item != null)
                    {
                        this.DataEnterers.Add(item);
                    }
                }
            }

            if (authorOrPerformers != null)
            {
                foreach (var item in authorOrPerformers)
                {
                    if (item != null)
                    {
                        this.AuthorOrPerformers.Add(item);
                    }
                }
            }

            if (informationRecipients != null)
            {
                foreach (var item in informationRecipients)
                {
                    if (item != null)
                    {
                        this.InformationRecipients.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="overseer">The overseer.</param>
        /// <param name="dataEnterers">The data enterers.</param>
        /// <param name="authorOrPerformers">The author or performers.</param>
        /// <param name="informationRecipients">The information recipients.</param>
        /// <param name="code">The code.</param>
        /// <param name="text">The text.</param>
        /// <param name="effectiveTime">The effective time.</param>
        /// <param name="priorityCode">The priority code.</param>
        /// <param name="reasonCodes">The reason codes.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="subject">The subject.</param>
        public HL7MessageControlAct(IEnumerable<HL7Overseer> overseer, IEnumerable<HL7DataEnterer> dataEnterers, IEnumerable<HL7AuthorOrPerformer> authorOrPerformers, ICollection<HL7InformationRecipient> informationRecipients, HL7ClassificatorId code, string text, DateTime? effectiveTime, HL7ClassificatorId priorityCode, ICollection<HL7ClassificatorId> reasonCodes, HL7ClassificatorId languageCode, HL7Subject subject)
            : base(code, effectiveTime, text, priorityCode, reasonCodes, languageCode, subject)
        {
            this.Overseer = new Collection<HL7Overseer>();
            this.DataEnterers = new Collection<HL7DataEnterer>();
            this.AuthorOrPerformers = new Collection<HL7AuthorOrPerformer>();
            this.InformationRecipients = new Collection<HL7InformationRecipient>();
            this.ReasonCodes = reasonCodes;

            if (overseer != null)
            {
                foreach (var item in overseer)
                {
                    if (item != null)
                    {
                        this.Overseer.Add(item);
                    }
                }
            }

            if (dataEnterers != null)
            {
                foreach (var item in dataEnterers)
                {
                    if (item != null)
                    {
                        this.DataEnterers.Add(item);
                    }
                }
            }

            if (authorOrPerformers != null)
            {
                foreach (var item in authorOrPerformers)
                {
                    if (item != null)
                    {
                        this.AuthorOrPerformers.Add(item);
                    }
                }
            }

            if (informationRecipients != null)
            {
                foreach (var item in informationRecipients)
                {
                    if (item != null)
                    {
                        this.InformationRecipients.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7MessageControlAct"/> class.
        /// </summary>
        /// <param name="reasonCodes">The reason codes.</param>
        protected HL7MessageControlAct(ICollection<HL7ClassificatorId> reasonCodes)
            : base(reasonCodes)
        {
            this.ReasonCodes = reasonCodes;
            this.DataEnterers = new Collection<HL7DataEnterer>();
            this.AuthorOrPerformers = new Collection<HL7AuthorOrPerformer>();
            this.InformationRecipients = new Collection<HL7InformationRecipient>();
        }

        /// <summary>
        /// Gets the author or performers.
        /// </summary>
        public ICollection<HL7Overseer> Overseer { get; private set; }

        /// <summary>
        /// Gets the author or performers.
        /// </summary>
        public ICollection<HL7AuthorOrPerformer> AuthorOrPerformers { get; private set; }

        /// <summary>
        /// Gets the data enterers.
        /// </summary>
        public ICollection<HL7DataEnterer> DataEnterers { get; private set; }

        /// <summary>
        /// Gets the information recipients.
        /// </summary>
        public ICollection<HL7InformationRecipient> InformationRecipients { get; private set; }
    }
}