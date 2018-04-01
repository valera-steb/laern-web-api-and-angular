using System.ComponentModel.DataAnnotations;

namespace Demo.Api.Model.Users
{
    public class UserPostModel
    {
        [MinLength(5)]
        [MaxLength(20)]
        [RegularExpression("^(\\w)+[\\w _]+$")]
        public string UserName { get; set; }
    }
}
