<template>
  <v-row>
    <v-col>
        <ConversationListItem v-for="item in conversations" :key="item.id"
                                 :id="item.id"
                                 :title="item.title"
                                 :updatedDate="item.updatedDate"
                                 :prompt="item.prompt"></ConversationListItem>
    </v-col>
  </v-row>
</template>

<script>
import ConversationListItem from "@/components/conversations/ConversationListItem.vue"
export default {
  name: 'ConversationsPage',
  components: {
      ConversationListItem
  },
  data() {
    return {
      conversations: [
        {
          id: 1,
          title: "Saturday tip of the day",
          updatedDate: '08/12/2023 3:57PM',
          prompt: "C# tip of the day"
        },
        {
          id: 2,
          title: "Friday tip of the day",
          updatedDate: '08/12/2023 3:57PM',
          prompt: "C# tip of the day"
        },
        {
          id: 3,
          title: "Thursday tip of the day",
          updatedDate: '08/12/2023 3:57PM',
          prompt: "C# tip of the day"
        }
      ]
    }
  }
}
</script>
