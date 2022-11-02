// ----------------------------------------------------------------------------
// <copyright file="HL7AsLicensedEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

///////////////////////////////////////////////////////////
//  Person.cs
//  Implementation of the Class Person
//  Generated by Enterprise Architect
//  Created on:      17-okt-2011 19:07:25
//  Original author: Jura
///////////////////////////////////////////////////////////

namespace Abc.ServiceModel.Protocol.HL7
{
    using System.Collections.Generic;

    /// <summary>
    /// HL7 sh�mas klase.  Personas apraksts.
    /// </summary>
    public class HL7AsLicensedEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AsLicensedEntity"/> class.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Code">The code.</param>
        /// <param name="OrgId">The org identifier.</param>
        public HL7AsLicensedEntity(ICollection<HL7II> Id, HL7ClassificatorId Code, ICollection<HL7II> OrgId)
        {
            this.Id = Id;
            this.Code = Code;
            this.OrgId = OrgId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AsLicensedEntity" /> class.
        /// </summary>
        protected HL7AsLicensedEntity()
        {
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public HL7ClassificatorId Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ICollection<HL7II> Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the org identifier.
        /// </summary>
        /// <value>
        /// The org identifier.
        /// </value>
        public ICollection<HL7II> OrgId
        {
            get;
            set;
        }
    }
}