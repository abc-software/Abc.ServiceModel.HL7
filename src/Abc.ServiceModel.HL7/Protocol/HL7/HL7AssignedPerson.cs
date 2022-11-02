// ----------------------------------------------------------------------------
// <copyright file="HL7AssignedPerson.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

///////////////////////////////////////////////////////////
//  AssignedDevice.cs
//  Implementation of the Class AssignedDevice
//  Generated by Enterprise Architect
//  Created on:      17-okt-2011 19:07:24
//  Original author: Jura
///////////////////////////////////////////////////////////

namespace Abc.ServiceModel.Protocol.HL7
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// HL7 sh�mas klase, Tie�i iesaist�tais ir persona vai ier�ce, dati par to ir nor�d�ti AssignedPerson vai AssignedDevice CMET. Ir j��em v�r�, ka bie�i darb�bas iniciatore vai izpild�t�ja ir organiz�cija nevis persona. Ar� ��d� gad�jum� ir j�izmanto AssignedPerson CMET, kas nodro�ina organiz�cijas, k� izpild�t�ja lomas re�istr��anu.
    /// </summary>
    public class HL7AssignedPerson
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personCode">The person code.</param>
        /// <param name="code">The code.</param>
        /// <param name="givenName">Name of the given.</param>
        /// <param name="familyName">Name of the family.</param>
        /// <param name="representedOrganization">The represented organization.</param>
        public HL7AssignedPerson(string personCode, HL7ClassificatorId code, string givenName, string familyName, HL7RepresentedOrganization representedOrganization)
            : this(new HL7PersonId(personCode), code, new HL7Person(givenName, familyName), null, representedOrganization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personCode">The person code.</param>
        /// <param name="code">The code.</param>
        /// <param name="givenName">Name of the given.</param>
        /// <param name="familyName">Name of the family.</param>
        public HL7AssignedPerson(string personCode, HL7ClassificatorId code, string givenName, string familyName)
            : this(new HL7PersonId(personCode), code, new HL7Person(givenName, familyName), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personCode">The person code.</param>
        /// <param name="code">The code.</param>
        /// <param name="givenName">Name of the given.</param>
        /// <param name="familyName">Name of the family.</param>
        /// <param name="telecom">The telecom.</param>
        /// <param name="asMember">As member.</param>
        /// <param name="representedOrganization">The represented organization.</param>
        public HL7AssignedPerson(string personCode, HL7ClassificatorId code, string givenName, string familyName, string telecom, HL7AsMember asMember, HL7RepresentedOrganization representedOrganization)
            : this(new HL7PersonId(personCode), code, new HL7Person(givenName, familyName), telecom, asMember, representedOrganization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personCode">The person code.</param>
        /// <param name="code">The code.</param>
        /// <param name="givenName">Name of the given.</param>
        /// <param name="familyName">Name of the family.</param>
        /// <param name="telecom">The telecom.</param>
        /// <param name="asMember">As member.</param>
        public HL7AssignedPerson(string personCode, HL7ClassificatorId code, string givenName, string familyName, string telecom, HL7AsMember asMember)
            : this(new HL7PersonId(personCode), code, new HL7Person(givenName, familyName), telecom, asMember)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson" /> class.
        /// </summary>
        /// <param name="personId">The person id.</param>
        /// <param name="code">The code.</param>
        /// <param name="person">The person.</param>
        /// <param name="asMember">As member.</param>
        /// <param name="representedOrganization">The represented organization.</param>
        public HL7AssignedPerson(HL7PersonId personId, HL7ClassificatorId code, HL7Person person, HL7AsMember asMember, HL7RepresentedOrganization representedOrganization)
            : this(personId, code, new Collection<HL7Person>() { person }, null, new Collection<HL7AsMember>() { asMember }, representedOrganization, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personId">The person id.</param>
        /// <param name="code">The code.</param>
        /// <param name="person">The person.</param>
        /// <param name="asMember">As member.</param>
        public HL7AssignedPerson(HL7PersonId personId, HL7ClassificatorId code, HL7Person person, HL7AsMember asMember)
            : this(personId, code, new Collection<HL7Person>() { person }, null, new Collection<HL7AsMember>() { asMember })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personId">The person id.</param>
        /// <param name="code">The code.</param>
        /// <param name="person">The person.</param>
        /// <param name="telecom">The telecom.</param>
        /// <param name="asMember">As member.</param>
        /// <param name="representedOrganization">The represented organization.</param>
        public HL7AssignedPerson(HL7PersonId personId, HL7ClassificatorId code, HL7Person person, string telecom, HL7AsMember asMember, HL7RepresentedOrganization representedOrganization)
            : this(personId, code, new Collection<HL7Person>() { person }, new Collection<string>() { telecom }, new Collection<HL7AsMember>() { asMember }, representedOrganization, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personId">The person id.</param>
        /// <param name="code">The code.</param>
        /// <param name="person">The person.</param>
        /// <param name="telecom">The telecom.</param>
        /// <param name="asMember">As member.</param>
        public HL7AssignedPerson(HL7PersonId personId, HL7ClassificatorId code, HL7Person person, string telecom, HL7AsMember asMember)
            : this(personId, code, new Collection<HL7Person>() { person }, new Collection<string>() { telecom }, new Collection<HL7AsMember>() { asMember })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        /// <param name="personId">The person id.</param>
        /// <param name="code">The code.</param>
        /// <param name="persons">The persons.</param>
        /// <param name="telecoms">The telecoms.</param>
        /// <param name="asMembers">As members.</param>
        public HL7AssignedPerson(HL7PersonId personId, HL7ClassificatorId code, IEnumerable<HL7Person> persons, IEnumerable<string> telecoms, IEnumerable<HL7AsMember> asMembers)
            : this(personId, code, persons, telecoms, asMembers, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson" /> class.
        /// </summary>
        /// <param name="personId">The person id.</param>
        /// <param name="code">The code.</param>
        /// <param name="persons">The persons.</param>
        /// <param name="telecoms">The telecom.</param>
        /// <param name="asMembers">As members.</param>
        /// <param name="representedOrganization">The represented organization.</param>
        /// <param name="asLicensedEntity">As licensed entity.</param>
        public HL7AssignedPerson(HL7PersonId personId, HL7ClassificatorId code, IEnumerable<HL7Person> persons, IEnumerable<string> telecoms, IEnumerable<HL7AsMember> asMembers, HL7RepresentedOrganization representedOrganization, IEnumerable<HL7AsLicensedEntity> asLicensedEntity)
        {
            this.PersonId = personId;
            this.Code = code;

            if (persons != null)
            {
                this.Persons = new Collection<HL7Person>();

                foreach (var item in persons)
                {
                    this.Persons.Add(item);
                }
            }

            if (telecoms != null)
            {
                this.Telecoms = new Collection<string>();

                foreach (var item in telecoms)
                {
                    this.Telecoms.Add(item);
                }
            }

            if (asMembers != null)
            {
                this.AsMembers = new Collection<HL7AsMember>();

                foreach (var item in asMembers)
                {
                    this.AsMembers.Add(item);
                }
            }

            this.RepresentedOrganization = representedOrganization;

            if (asLicensedEntity != null)
            {
                this.AsLicensedEntity = new Collection<HL7AsLicensedEntity>();

                foreach (var item in asLicensedEntity)
                {
                    this.AsLicensedEntity.Add(item);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HL7AssignedPerson"/> class.
        /// </summary>
        protected HL7AssignedPerson()
        {
        }

        /// <summary>
        /// Gets or sets as licensed entity.
        /// </summary>
        /// <value>
        /// As licensed entity.
        /// </value>
        public ICollection<HL7AsLicensedEntity> AsLicensedEntity
        {
            get;
            set;
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

        /// <value>
        /// The author or performer data.
        /// </value>
        /// <summary>
        /// Gets or sets the person id.
        /// </summary>
        /// <value>
        /// The person id.
        /// </value>
        public HL7PersonId PersonId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public ICollection<HL7Person> Persons
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

        /// <summary>
        /// Gets or sets the telecom.
        /// </summary>
        /// <value>
        /// The telecom.
        /// </value>
        public ICollection<string> Telecoms
        {
            get;
            set;
        }
    }
}