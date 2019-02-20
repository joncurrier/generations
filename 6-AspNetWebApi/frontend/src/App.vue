<template>
  <div id="app">
    <sidebar></sidebar>
    <router-view></router-view>
  </div>
</template>

<script>
import Sidebar from './components/Sidebar.vue'
export default {
  name: 'app',
  components: {
    'sidebar': Sidebar
  }
}
</script>
