from django.urls import path

from . import views

app_name = 'recipes'
urlpatterns = [
    # ex: /artichoke-dip/
    path('<slug:slug>/',
        views.RecipeDetailView.as_view(),
        name='detail'),
]
