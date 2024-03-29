// ----------------------------------------------------------------------------
// <copyright file="HL7AssignedDevice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Abc.ServiceModel.Protocol.HL7
{
    ///////////////////////////////////////////////////////////
    //  AssignedDevice.cs
    //  Implementation of the Class AssignedDevice
    //  Generated by Enterprise Architect
    //  Created on:      17-okt-2011 19:07:24
    //  Original author: Jura
    ///////////////////////////////////////////////////////////
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// HL7 sh�mas klase, Tie�i iesaist�tais ir persona vai ier�ce, dati par to ir nor�d�ti AssignedPerson vai AssignedDevice CMET. Ir j��em v�r�, ka bie�i darb�bas iniciatore vai izpild�t�ja ir organiz�cija nevis persona. Ar� ��d� gad�jum� ir j�izmanto AssignedPerson CMET, kas nodro�ina organiz�cijas, k� izpild�t�ja lomas re�istr��anu.
    /// </summary>
    public class HL7AssignedDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedDevice"/> class.
        /// </summary>
        /// <param name="id">The id. value</param>
        public HL7AssignedDevice(HL7II id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedDevice"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="asMembers">As members.</param>
        /// <param name="representedOrganization">The represented organization.</param>
        public HL7AssignedDevice(HL7II id, IEnumerable<HL7AsMember> asMembers, HL7RepresentedOrganization representedOrganization)
        {
            this.Id = id;

            if (asMembers != null)
            {
                this.AsMembers = new Collection<HL7AsMember>();

                foreach (var item in asMembers)
                {
                    this.AsMembers.Add(item);
                }
            }

            this.RepresentedOrganization = representedOrganization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedDevice"/> class.
        /// </summary>
        protected HL7AssignedDevice()
        {
        }

        /// <summary>
        /// Gets or sets as members.
        /// </summary>
        /// <value>
        /// As members.
        /// </value>
        public ICollection<HL7AsMember> AsMembers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public HL7II Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the represented organization.
        /// </summary>
        /// <value>
        /// The represented organization.
        /// </value>
        public HL7RepresentedOrganization RepresentedOrganization
        {
            get;
            set;
        }
    }
}