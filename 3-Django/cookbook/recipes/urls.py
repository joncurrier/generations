from django.conf.urls import url

from . import views

urlpatterns = [
    # ex: /artichoke-dip/
    url(r'^(?P<slug>[-\w\d]+)/$',
        views.RecipeDetailView.as_view(),
        name='detail'),
]
