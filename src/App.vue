<template>
  <div>
    <h1>Music List</h1>
    <ul>
      <li v-for="song in songs" :key="song.id">{{ song.title }} - {{ song.artist }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      songs: []
    };
  },
  async created() {
    try {
      const res = await fetch('/api/songs');
      if (res.ok) {
        this.songs = await res.json();
      }
    } catch (e) {
      console.error(e);
    }
  }
};
</script>

<style>
ul { list-style-type: none; padding: 0; }
li { margin-bottom: 5px; }
</style>
