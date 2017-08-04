from rest_framework import serializers

from .models import Category, Recipe, Ingredient, Direction


class IngredientSerializer(serializers.ModelSerializer):

    class Meta:
        model = Ingredient
        fields = ('text', )


class DirectionSerializer(serializers.ModelSerializer):

    class Meta:
        model = Direction
        fields = ('ordinal', 'text')


class RecipeSerializer(serializers.HyperlinkedModelSerializer):
    ingredients = IngredientSerializer(many=True, read_only=True)
    directions = DirectionSerializer(many=True, read_only=True)

    class Meta:
        model = Recipe
        fields = ('url', 'title', 'slug', 'description', 'yields',
                  'ingredients', 'directions', 'get_prep_time', 'get_wait_time', 'get_cook_time', )
        extra_kwargs = {
            'url': {'lookup_field': 'slug'}
        }


class ShortRecipeSerializer(serializers.HyperlinkedModelSerializer):

    class Meta:
        model = Recipe
        fields = ('url', 'title', 'slug')
        extra_kwargs = {
            'url': {'lookup_field': 'slug'}
        }


class CategorySerializer(serializers.HyperlinkedModelSerializer):
    recipes = ShortRecipeSerializer(many=True, read_only=True)

    class Meta:
        model = Category
        fields = ('url', 'name', 'name_plural', 'ordinal', 'recipes')
        extra_kwargs = {
            'url': {'lookup_field': 'slug'}
        }
