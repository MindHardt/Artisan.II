﻿using Artisan.II.Data.Abstractions;
using Artisan.II.Data.Entities.UserFiles;
using Microsoft.EntityFrameworkCore;

namespace Artisan.II.Data.EFCore.Repositories;

public class UserFileEfCoreRepository :
    EfCoreRepositoryBase<UserFile>,
    IUserFileRepository
{
    public UserFileEfCoreRepository(DbContext ctx) : base(ctx)
    {
    }

    public async ValueTask<UserFile?> GetByName(UserFileScope scope, string fileName)
    {
        return await Set
            .Where(x => x.Scope == scope)
            .Where(x => x.Name == fileName)
            .FirstOrDefaultAsync();
    }

    public async ValueTask<UserFile> SaveFile(UserFile file)
    {
        var entry = Set.Add(file);
        await CommitAsync();
        return entry.Entity;
    }

    public async ValueTask<IReadOnlyCollection<UserFileInfo>> FindFiles(
        string prompt, 
        int maximum, 
        UserFileScope? scope = null)
    {
        return await Set
            .Where(x => scope == null || scope == x.Scope)
            .Where(x => EF.Functions.Like(x.Name, $"%{prompt}%"))
            .OrderBy(x => x.Name)
            .Take(maximum)
            .Select(x => UserFileInfo.FromUserFile(x))
            .ToArrayAsync();
    }
}