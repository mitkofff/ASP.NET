﻿namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.Section;

    public interface ISectionsService
    {
        Task<int> CreateAsync(CreateSectionInputModel input);

        Task EditAsync(int id, CreateSectionInputModel input);

        Section GetSectionById(int id);
    }
}
