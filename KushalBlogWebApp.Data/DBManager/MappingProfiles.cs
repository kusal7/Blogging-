using AutoMapper;
using KushalBlogWebApp.Data.Common.Paging;

namespace TeamEleven.Data.Common
{
    /// <summary>
    /// The mapping profiles.
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
        /// </summary>
        public MappingProfiles()
        {

            CreateMap(typeof(PagedInfo), typeof(PagedResponse<>)).ReverseMap();
        }
    }
}
