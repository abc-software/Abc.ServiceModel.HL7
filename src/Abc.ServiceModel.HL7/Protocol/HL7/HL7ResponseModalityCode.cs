// ----------------------------------------------------------------------------
// <copyright file="HL7ResponseModalityCode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

///////////////////////////////////////////////////////////
//  HL7Id.cs
//  Implementation of the Class HL7Id
//  Generated by Enterprise Architect
//  Created on:      18-okt-2011 11:58:56
//  Original author: Jura
///////////////////////////////////////////////////////////

namespace Abc.ServiceModel.Protocol.HL7
{
    /// <summary>
    /// HL7 sh�mas klase. Nosaka rezult�jo�� saraksta laika interv�lu un grup��anu. [3]
    /// </summary>
    public class HL7ResponseModalityCode
    {
        private HL7ResponseModalityCodes code;

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7ResponseModalityCode"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public HL7ResponseModalityCode(HL7ResponseModalityCodes code)
        {
            this.code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7ResponseModalityCode"/> class.
        /// </summary>
        protected HL7ResponseModalityCode()
        {
        }

        /// <summary>
        /// A code specifying the state of the Query.
        /// </summary>
        public enum HL7ResponseModalityCodes
        {
            /// <summary>
            /// Query response to be sent as an HL7 Batch. B (batch) � vaic�juma atbildei, j�b�t izs�t�tai k� HL7 batch
            /// </summary>
            Batch,

            /// <summary>
            /// Query response to occur in real time. R (re�l� laika piepras�jums) � vaic�juma atbilde, kas notiek re�l� laik�
            /// </summary>
            RealTime,

            /// <summary>
            /// Query response to sent as a series of responses at the same time without the use of batch formatting. B vaic�juma atbilde, kas vienlaic�gi tiek s�t�ta k� atbil�u s�rija, nepielietojot batch format�jumu
            /// </summary>
            Bolus
        }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public virtual HL7ResponseModalityCodes Code
        {
            get
            {
                return this.code;
            }

            set
            {
                // regex
                this.code = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.code.ToString();
        }
    }
}