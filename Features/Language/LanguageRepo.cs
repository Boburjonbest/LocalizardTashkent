﻿using AutoMapper;
using Localizard.Domain.Entites;
using Localizard.Domain.Enums;
using Localizard.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Localizard.DAL.Repositories.Implementations;

public class LanguageRepo : ILanguageRepo
{
    
    private readonly AppDbContext _context;

    public LanguageRepo(AppDbContext context)
    {
        _context = context;
    }
    public List<Language> GetAll()
    {
        return _context.Languages.OrderBy(l => l.Id).ToList();
    }

    public async Task<Language> GetById(int id)
    {
        return await _context.Languages.FirstOrDefaultAsync(l => l.Id == id);
    }

    public bool LanguageExists(int id)
    {
        return _context.Languages.Any(l => l.Id == id);
    }

    public bool CteateLanguage(Language language)
    {
        _context.Add(language);
        return Save();
    }

    public bool UpdateLanguage(Language language)
    {
        _context.Update(language);
        return Save();
    }

    public bool DeleteLanguage(int id)
    {
        var language = _context.Languages
            .Include(l => l.ProjectInfos)
            .Include(l => l.Translations)
            .FirstOrDefault(l => l.Id == id);

        if (language == null)
        {
            return false;
        }

        if (language.Translations != null && language.Translations.Any())
        {
            _context.Translations.RemoveRange(language.Translations);
        }
        
        _context.Languages.Remove(language);

        return Save();  
    }
    
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}