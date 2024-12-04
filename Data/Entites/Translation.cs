﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Localizard.Domain.Entites;

namespace Localizard.Data.Entites;

public class  Translation
{
    [Key] 
    public int Id { get; set; }
    public string SymbolKey { get; set; }
    public int LanguageId { get; set; }
    public string Text { get; set; }
    [JsonIgnore]
    public Language Language { get; set; }
    [JsonIgnore]
    public virtual ProjectDetail ProjectDetails { get; set; }

}