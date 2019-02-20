<template>
  <div id="sidebar" class="ui left vertical inverted menu">
    <div class="toc">
      <div class="item" v-for="category in categories" :key="category.id">
        <div class="header">{{ category.name_plural }}</div>
        <div class="menu">
          <router-link :to="{ name: 'recipe', params: { slug: recipe.slug }}" activeClass="active" class="item" v-for="recipe in category.recipes" :key="recipe.title">
            {{ recipe.title }}
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Api from '@/utils/api'

export default {
  data: function () {
    return {
      categories: []
    }
  },
  mounted: function () {
    this.getCategories()
  },
  methods: {
    getCategories: function () {
      Api.get('/api/categories').then(response => {
        this.categories = response.data
      })
    }
  }
}
</script>
