using Web.Infrastructure.Storage;

namespace Web.Models {
    /// <summary>
    /// This is the EF site alternative
    /// </summary>
    public class SiteEFSession:EFSession {
        public SiteEFSession():base(new SiteEntities()) {}
    }
}