<template>
  <EditConversation :prompts="prompts"></EditConversation>
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
      prompts:[],
    }
  },
  async asyncData(context) {
    const prompts = await context.app.$axios.$get('api/Prompts');
    return {
      prompts: prompts
    };
  }
}
</script>
