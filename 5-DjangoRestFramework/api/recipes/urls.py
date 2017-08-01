from django.conf.urls import url, include

from rest_framework.routers import DefaultRouter

from . import api_views

router = DefaultRouter()
router.register(r'categories', api_views.CategoryViewSet)
router.register(r'recipes', api_views.RecipeViewSet)

urlpatterns = [
    url(r'^', include(router.urls)),
]
