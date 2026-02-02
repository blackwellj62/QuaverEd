<template>
  <div class="container py-4">
    <h1 class="h4 mb-3">Repository Details</h1>
    <p class="text-muted">Detail view placeholder for id: {{ id }}</p>
  </div>
</template>

<script setup>
defineProps({
  id: { type: String, required: true }
})
</script>