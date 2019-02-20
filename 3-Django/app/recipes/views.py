from django.shortcuts import render
from django.views.generic import DetailView

from .models import Category, Recipe

class RecipeDetailView(DetailView):
    model = Recipe

    def get_context_data(self, **kwargs):
        context = super(RecipeDetailView, self).get_context_data(**kwargs)
        context['category_list'] = Category.objects.all()
        return context
