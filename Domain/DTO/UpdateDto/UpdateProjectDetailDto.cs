﻿namespace Localizard.Domain.ViewModel;

public class UpdateProjectDetailDto
{
    public int Id { get; set; }
    public string Key { get; set; }
    public int TranslationId { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
}