<template>
  <EditConversation 
      :id="conversation.id"
      :title="conversation.title"
      :prompt="conversation.prompt"
      :prompts="prompts"></EditConversation>
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
      prompts:[],
    }
  },
  computed:{
    conversationId(){
      return parseInt(this.$route.params.conversationId);
    }
  },
  //async fetch() {
  //  debugger;
  //  this.posts = await this.$http.$get('https://api.nuxtjs.dev/posts');
  //  console.log('this.posts:', this.posts);
  //},
  async asyncData(context) {
    const conversation = await context.app.$axios.$get('api/Conversations/'+context.params.conversationId);
    const prompts = await context.app.$axios.$get('api/Prompts');
    return {
      conversation: {
        id: conversation.id,
        title: conversation.title,
        updatedDate: new Date(conversation.updatedDate),
        prompt: conversation.prompt,

      },
      prompts: prompts
    };
    //return context.app.$axios.$get('api/Conversations/'+context.params.conversationId)
    //    .then(response => {
    //      return {
    //        conversation: {
    //            id: response.id,
    //            title: response.title,
    //            updatedDate: new Date(response.updatedDate),
    //            promptName: response.promptName
    //          }
    //      }
    //    });
  }
}
</script>
