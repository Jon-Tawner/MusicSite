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
      songs: [
        { id: 1, title: 'Song A', artist: 'Artist 1' },
        { id: 2, title: 'Song B', artist: 'Artist 2' },
        { id: 3, title: 'Song C', artist: 'Artist 3' }
      ]
    };
  }
};
</script>

<style>
ul { list-style-type: none; padding: 0; }
li { margin-bottom: 5px; }
</style>
