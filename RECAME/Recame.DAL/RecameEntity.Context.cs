﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recame.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RecameDBEntities : DbContext
    {
        public RecameDBEntities()
            : base("name=RecameDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<FoodShop> FoodShops { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemIngredient> MenuItemIngredients { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
        public virtual DbSet<TranslationEntry> TranslationEntries { get; set; }
    
        [DbFunction("RecameDBEntities", "fn_FoodShop")]
        public virtual IQueryable<fnFoodShop> fn_FoodShop(string lang)
        {
            var langParameter = lang != null ?
                new ObjectParameter("lang", lang) :
                new ObjectParameter("lang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnFoodShop>("[RecameDBEntities].[fn_FoodShop](@lang)", langParameter);
        }
    
        [DbFunction("RecameDBEntities", "fn_Ingredient")]
        public virtual IQueryable<fnIngredient> fn_Ingredient()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnIngredient>("[RecameDBEntities].[fn_Ingredient]()");
        }
    
        [DbFunction("RecameDBEntities", "fn_Menu")]
        public virtual IQueryable<fnMenu> fn_Menu()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnMenu>("[RecameDBEntities].[fn_Menu]()");
        }
    
        [DbFunction("RecameDBEntities", "fn_MenuItem")]
        public virtual IQueryable<fnMenuItem> fn_MenuItem()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnMenuItem>("[RecameDBEntities].[fn_MenuItem]()");
        }
    
        [DbFunction("RecameDBEntities", "fn_MenuItemIngredient")]
        public virtual IQueryable<fnMenuItemIngredient> fn_MenuItemIngredient()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnMenuItemIngredient>("[RecameDBEntities].[fn_MenuItemIngredient]()");
        }
    
        [DbFunction("RecameDBEntities", "fn_Translation")]
        public virtual IQueryable<fnTranslation> fn_Translation(string language)
        {
            var languageParameter = language != null ?
                new ObjectParameter("Language", language) :
                new ObjectParameter("Language", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnTranslation>("[RecameDBEntities].[fn_Translation](@Language)", languageParameter);
        }
    
        [DbFunction("RecameDBEntities", "fn_TranslationEntry")]
        public virtual IQueryable<fnTranslationEntry> fn_TranslationEntry(Nullable<int> translationId)
        {
            var translationIdParameter = translationId.HasValue ?
                new ObjectParameter("TranslationId", translationId) :
                new ObjectParameter("TranslationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnTranslationEntry>("[RecameDBEntities].[fn_TranslationEntry](@TranslationId)", translationIdParameter);
        }
    
        [DbFunction("RecameDBEntities", "fn_TranslationEntryDef")]
        public virtual IQueryable<fnTranslationEntryDef> fn_TranslationEntryDef(string language)
        {
            var languageParameter = language != null ?
                new ObjectParameter("Language", language) :
                new ObjectParameter("Language", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnTranslationEntryDef>("[RecameDBEntities].[fn_TranslationEntryDef](@Language)", languageParameter);
        }
    }
}
