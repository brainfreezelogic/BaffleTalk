using System;
using System.Data.Entity;
using BaffleTalk.Data.Entities.Membership;

namespace BaffleTalk.Data.Context
{
    public class BaffleTalkContext : DbContext, IDisposable
    {
        private readonly bool rollbackOnDispose;

        public DbSet<User> Users { get; set; }
        public DbSet<UserOathData> UserOathData { get; set; }
        public DbSet<OauthProvider> OauthProvider { get; set; }

        public BaffleTalkContext() : this(false) { }

        public BaffleTalkContext(bool rollbackOnDispose)
        {
            this.rollbackOnDispose = rollbackOnDispose;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region User

            modelBuilder.Entity<User>()
                .Property(m => m.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(m => m.UniqueName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(m => m.DisplayName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(m => m.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(m => m.PasswordSalt)
                .IsRequired();

            #endregion

            #region UserOauthData

            modelBuilder.Entity<UserOathData>()
                .HasKey(m => m.UserId);

            modelBuilder.Entity<UserOathData>()
                .Property(m => m.OathData)
                .IsRequired();

            #endregion

            #region OauthProvider

            modelBuilder.Entity<OauthProvider>()
                .Property(m => m.Name)
                .IsRequired();

            #endregion
        }

        public void Commit()
        {
            SaveChanges();
        }

        public new void Dispose()
        {
            if (!rollbackOnDispose) SaveChanges();
            base.Dispose();
        }
    }
}