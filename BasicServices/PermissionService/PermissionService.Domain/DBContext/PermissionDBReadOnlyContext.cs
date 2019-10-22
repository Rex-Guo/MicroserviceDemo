﻿using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionService.Domain
{
    public class PermissionDBReadOnlyContext : PermissionDBContext
    {
        public PermissionDBReadOnlyContext(DbContextOptions<PermissionDBContext> options, IHttpContextAccessor httpContextAccessor)
                : base(options, httpContextAccessor)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override int SaveChanges()
        {
            throw new FriendlyException()
            {
                ExceptionCode = 403,
                ExceptionMessage = $"ReadOnlyDBContext SaveChanges is forbidden."
            };
            //return 0;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new FriendlyException()
            {
                ExceptionCode = 403,
                ExceptionMessage = $"ReadOnlyDBContext SaveChangesAsync is forbidden."
            };
            //return new Task<int>(t => 0, cancellationToken);
        }
    }
}