<template>
  <nuxt-link :to="`/conversations/${id}`">
    <v-card class="mx-auto" width="400" variant="tonal">
      <v-card-text>
        <div class="text-h6">
          {{ title }}
        </div>
        <div class="text-caption">
          {{ updatedDate.toLocaleString() }}
        </div>
        <div v-if="prompt" class="text--primary">
          Prompt: {{ prompt }}
        </div>
      </v-card-text>
    </v-card>
  </nuxt-link>
</template>

<script>
export default {
  props: {
    id: {
      type: Number,
      required: true
    },
    title: {
      type: String,
      required: true
    },
    updatedDate: {
      type: Date,
      required: true
    },
    prompt: {
      type: String,
      default: null
    }
  }
}
</script>

<style scoped>
  a {
    text-decoration: none;
  }
  .v-card {
    margin: 10px 0;
  }
</style>
