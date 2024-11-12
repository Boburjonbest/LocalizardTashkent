﻿using AutoMapper.Configuration.Annotations;
using Localizard.Domain.Entites;
using Localizard.Domain.Enums;

namespace Localizard.Domain.ViewModel;

public class ProjectInfoDto
{
    public string Name { get; set; }
    public int DefaultLanguageId { get; set; } 
    public int ProjectDetailId { get; set; }
    public int[] AvailableLanguageIds { get; set; } = null!;
    public List<LanguageDto> AvailableLanguageId { get; set; } = new List<LanguageDto>();
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
}