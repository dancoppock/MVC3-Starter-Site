﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace Web.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SiteEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SiteEntities object using the connection string found in the 'SiteEntities' section of the application configuration file.
        /// </summary>
        public SiteEntities() : base("name=SiteEntities", "SiteEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SiteEntities object.
        /// </summary>
        public SiteEntities(string connectionString) : base(connectionString, "SiteEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SiteEntities object.
        /// </summary>
        public SiteEntities(EntityConnection connection) : base(connection, "SiteEntities")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SiteModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="openID">Initial value of the OpenID property.</param>
        /// <param name="lastLogin">Initial value of the LastLogin property.</param>
        /// <param name="createdOn">Initial value of the CreatedOn property.</param>
        /// <param name="modifiedOn">Initial value of the ModifiedOn property.</param>
        /// <param name="friendly">Initial value of the Friendly property.</param>
        public static User CreateUser(global::System.Guid id, global::System.String userName, global::System.String openID, global::System.DateTime lastLogin, global::System.DateTime createdOn, global::System.DateTime modifiedOn, global::System.String friendly)
        {
            User user = new User();
            user.ID = id;
            user.UserName = userName;
            user.OpenID = openID;
            user.LastLogin = lastLogin;
            user.CreatedOn = createdOn;
            user.ModifiedOn = modifiedOn;
            user.Friendly = friendly;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String OpenID
        {
            get
            {
                return _OpenID;
            }
            set
            {
                OnOpenIDChanging(value);
                ReportPropertyChanging("OpenID");
                _OpenID = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("OpenID");
                OnOpenIDChanged();
            }
        }
        private global::System.String _OpenID;
        partial void OnOpenIDChanging(global::System.String value);
        partial void OnOpenIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastLogin
        {
            get
            {
                return _LastLogin;
            }
            set
            {
                OnLastLoginChanging(value);
                ReportPropertyChanging("LastLogin");
                _LastLogin = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLogin");
                OnLastLoginChanged();
            }
        }
        private global::System.DateTime _LastLogin;
        partial void OnLastLoginChanging(global::System.DateTime value);
        partial void OnLastLoginChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreatedOn
        {
            get
            {
                return _CreatedOn;
            }
            set
            {
                OnCreatedOnChanging(value);
                ReportPropertyChanging("CreatedOn");
                _CreatedOn = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreatedOn");
                OnCreatedOnChanged();
            }
        }
        private global::System.DateTime _CreatedOn;
        partial void OnCreatedOnChanging(global::System.DateTime value);
        partial void OnCreatedOnChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime ModifiedOn
        {
            get
            {
                return _ModifiedOn;
            }
            set
            {
                OnModifiedOnChanging(value);
                ReportPropertyChanging("ModifiedOn");
                _ModifiedOn = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifiedOn");
                OnModifiedOnChanged();
            }
        }
        private global::System.DateTime _ModifiedOn;
        partial void OnModifiedOnChanging(global::System.DateTime value);
        partial void OnModifiedOnChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Friendly
        {
            get
            {
                return _Friendly;
            }
            set
            {
                OnFriendlyChanging(value);
                ReportPropertyChanging("Friendly");
                _Friendly = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Friendly");
                OnFriendlyChanged();
            }
        }
        private global::System.String _Friendly;
        partial void OnFriendlyChanging(global::System.String value);
        partial void OnFriendlyChanged();

        #endregion
    
    }

    #endregion
    
}