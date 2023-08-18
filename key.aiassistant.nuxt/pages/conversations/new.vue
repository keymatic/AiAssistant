<template>
  <EditConversation :prompts="prompts" />
</template>

<script>
import EditConversation from '@/components/conversations/EditConversation.vue'

export default {
  name: 'ConversationPage',
  components: {
    EditConversation
  },
  async asyncData (context) {
    const prompts = await context.app.$axios.$get('api/Prompts')
    return {
      prompts
    }
  },
  data () {
    return {
      prompts: []
    }
  }
}
</script>
