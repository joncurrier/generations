from django.db import models

from . import utils


class Category(models.Model):
    """
    A category of recipes used to search and organize.
    """
    name = models.CharField(max_length=50)
    name_plural = models.CharField(max_length=50)
    slug = models.SlugField(max_length=50)
    ordinal = models.IntegerField(unique=True)

    class Meta:
        verbose_name = 'category'
        verbose_name_plural = 'categories'
        ordering = ('ordinal', )

    def __str__(self):
        return self.name


class Recipe(models.Model):
    """
    A recipe.
    """
    title = models.CharField(max_length=100)
    slug = models.SlugField(max_length=100)
    description = models.TextField()
    prep_time = models.DurationField(blank=True, null=True)
    wait_time = models.DurationField(blank=True, null=True)
    cook_time = models.DurationField(blank=True, null=True)
    yields = models.CharField(max_length=100, blank=True)
    category = models.ForeignKey(Category,
                                 on_delete=models.CASCADE,
                                 related_name='recipes')

    def get_prep_time(self):
        return utils.format_duration(self.prep_time)

    def get_wait_time(self):
        return utils.format_duration(self.wait_time)

    def get_cook_time(self):
        return utils.format_duration(self.cook_time)

    def __str__(self):
        return self.title

    class Meta:
        verbose_name = 'recipe'
        verbose_name_plural = 'recipes'


class Ingredient(models.Model):
    """
    A recipe ingredient, including an amount, a unit, and a food.
    """
    recipe = models.ForeignKey(Recipe,
                               on_delete=models.CASCADE,
                               related_name='ingredients')
    quantity = models.FloatField()
    unit = models.CharField(max_length=50, blank=True)
    food = models.CharField(max_length=50)

    def text(self):
        return utils.format_quantity(self.quantity, self.unit, self.food)

    def __str__(self):
        return '{recipe}: {quantity} {unit} {food}'.format(
            recipe=str(self.recipe),
            quantity=str(self.quantity),
            unit=str(self.unit),
            food=str(self.food),
        )

    class Meta:
        ordering = ('id', )


class Direction(models.Model):
    """
    A step in a recipe's directions.
    """
    recipe = models.ForeignKey(Recipe,
                               on_delete=models.CASCADE,
                               related_name='directions')
    text = models.TextField()
    ordinal = models.IntegerField()

    class Meta:
        ordering = ['recipe', 'ordinal', ]

    def __str__(self):
        return '{recipe} ({ordinal}): {text}'.format(
            recipe=str(self.recipe),
            ordinal=self.ordinal,
            text=self.text[:100],
        )
