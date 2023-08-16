<template>
  <v-row>
    <v-col>
      <v-row>
        <v-col>
          <NuxtLink to="/conversations/new">
            <v-btn variant="tonal">
              <v-icon>mdi-plus</v-icon>
              Start new conversation
            </v-btn>
          </NuxtLink>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <ConversationListItem v-for="item in conversations" :key="item.id"
                                :id="item.id"
                                :title="item.title"
                                :updatedDate="item.updatedDate"
                                :prompt="item.promptName"></ConversationListItem>
        </v-col>
      </v-row>
    </v-col>
  </v-row>
</template>

<script>
import ConversationListItem from "@/components/conversations/ConversationListItem.vue";

export default {
  name: 'ConversationsPage',
  components: {
      ConversationListItem
  },
  asyncData(context) {
    return context.app.$axios.$get('api/Conversations')
        .then(response => {
          return {
            conversations: response.map(c => {
              return {
                id: c.id,
                title: c.title,
                updatedDate: new Date(c.updatedDate),
                promptName: c.promptName
              };
            })
          }
        });
    }
  }
</script>
