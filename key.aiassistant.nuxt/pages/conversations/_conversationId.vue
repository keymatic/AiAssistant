<template>
  <EditConversation
    :id="conversation.id"
    :title="conversation.title"
    :prompt="conversation.prompt"
    :messages="messages"
    :prompts="prompts"
  />
</template>

<script>
import EditConversation from '@/components/conversations/EditConversation.vue'

export default {
  name: 'ConversationPage',
  components: {
    EditConversation
  },
  async asyncData (context) {
    const conversation = await context.app.$axios.$get('api/Conversations/' + context.params.conversationId)
    const prompts = await context.app.$axios.$get('api/Prompts')
    const messages = await context.app.$axios.$get(`api/Conversations/${context.params.conversationId}/Messages`)
    return {
      conversation: {
        id: conversation.id,
        title: conversation.title,
        updatedDate: new Date(conversation.updatedDate),
        prompt: conversation.prompt
      },
      prompts,
      messages
    }
  },
  data () {
    return {
      conversation: {},
      prompts: []
    }
  },
  computed: {
    conversationId () {
      return parseInt(this.$route.params.conversationId)
    }
  }
}
</script>
