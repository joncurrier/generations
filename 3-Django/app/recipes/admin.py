from django.contrib import admin

from . import models

class DirectionInline(admin.TabularInline):
    model = models.Direction
    extra = 1

class IngredientInline(admin.TabularInline):
    model = models.Ingredient
    extra = 1

class RecipeAdmin(admin.ModelAdmin):
    inlines = [
        DirectionInline,
        IngredientInline,
    ]

admin.site.register(models.Category)
admin.site.register(models.Recipe, RecipeAdmin)
