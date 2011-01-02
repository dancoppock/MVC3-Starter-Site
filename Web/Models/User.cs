using System;

namespace Web.Models {
    public partial class User {
        public User() {
            ID = Guid.NewGuid();
        }
        /*
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string OpenID { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Friendly { get; set; }

        public User() {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            LastLogin = DateTime.Now;
            UserName = "";
        }


        */

        public void JustLoggedIn() {
            ModifiedOn = DateTime.Now;
            LastLogin = DateTime.Now;
        }

        //overrides basic equality. By overriding this
        //you're telling the container how to find this object
        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(User)) {
                var comp = (User)obj;
                return comp.UserName.Equals(this.UserName);
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return this.UserName;
        }
    }
}
