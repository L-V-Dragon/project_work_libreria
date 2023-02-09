using Microsoft.AspNetCore.Identity;

namespace project_work_libreria.Models {
    public class UserForView {

        public IdentityUser User { get; set; }
        public IdentityRole? UserRuolo { get; set; }
        public List<IdentityRole>? Ruoli { get; set; }

    }
}
