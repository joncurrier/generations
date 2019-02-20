<template>
  <div id="recipe-container">
    <div id="recipe">
      <div>
        <div class="ui basic center aligned segment">
          <h1 class="ui header">{{ recipe.title }}</h1>
          <p>{{ recipe.description }}</p>
          <p v-if="recipe.yields">
            <strong>Yields:</strong> {{ recipe.yields }}
          </p>
          <div class="ui message">
            <i class="wait icon"></i>
            <span v-if="recipe.get_prep_time" class="timer"><strong>Prep:</strong> {{ recipe.get_prep_time }}</span>
            <span v-if="recipe.get_wait_time" class="timer"><strong>Wait:</strong> {{ recipe.get_wait_time }}</span>
            <span v-if="recipe.get_cook_time" class="timer"><strong>Cook:</strong> {{ recipe.get_cook_time }}</span>
          </div>
        </div>
        <div class="ui stackable grid">
          <div class="six wide column">
            <h2 class="ui header">Ingredients</h2>
            <div class="ui relaxed list">
              <div class="ui item" :key="ingredient.text" v-for="ingredient in recipe.ingredients">
                <i class="square outline icon"></i>
                <div class="content">
                  {{ ingredient.text }}
                </div>
              </div>
            </div>
          </div>
          <div class="ten wide column">
            <h2 class="ui header">Directions</h2>
            <ol class="ui relaxed list">
              <li :key="direction.ordinal" v-for="direction in recipe.directions" class="item">
                {{ direction.text }}
              </li>
            </ol>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Api from '@/utils/api'

export default {
  props: ['slug'],
  data: function () {
    return {
      recipe: {}
    }
  },
  mounted: function () {
    this.getRecipe()
  },
  watch: {
    // call again the method if the route changes
    '$route': 'getRecipe'
  },
  methods: {
    getRecipe: function () {
      Api.get('/api/recipes/' + this.slug).then(response => {
        this.recipe = response.data
        document.title = '6 - ' + this.recipe.title
      })
    }
  }
}
</script>
