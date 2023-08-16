<template>
  <EditConversation 
      :id="conversation.id"
      :title="conversation.title"
      :prompt="conversation.prompt"></EditConversation>
</template>

<script>
import EditConversation from "@/components/conversations/EditConversation.vue";

export default {
  name: 'ConversationPage',
  components: {
      EditConversation
  },
  data() {
    return {
      conversation: {},
    }
  },
  computed:{
    conversationId(){
      return parseInt(this.$route.params.conversationId);
    }
  },
  async asyncData(context) {
    const conversation = await context.app.$axios.$get('api/Conversations/'+context.params.conversationId);
    return {
      conversation: {
        id: conversation.id,
        title: conversation.title,
        updatedDate: new Date(conversation.updatedDate),
        prompt: conversation.prompt,

      },
    };
  }
}
</script>
