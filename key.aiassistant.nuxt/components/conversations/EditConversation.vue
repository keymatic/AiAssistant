<template>
  <v-row>
    <v-col cols="2" md="4">
      <v-form ref="form">
        <v-text-field
          v-model="conversation.title"
          :rules="[required]"
          :readonly="loading"
          label="Title"
        />

        <v-select
          v-if="!id"
          v-model="conversation.prompt"
          :items="promptItems"
          :readonly="loading"
          item-value="id"
          item-text="title"
          label="Prompt"
          clearable
          return-object
          single-line
        />

        <div class="d-flex flex-column">
          <v-btn
            color="success"
            class="mt-4"
            block
            @click.prevent="submitForm"
          >
            Submit
          </v-btn>
        </div>
      </v-form>
    </v-col>
    <v-col v-if="conversation.messages" cols="2" md="8">
      <v-card>
        <v-card-text>
          <v-timeline
            align-top
            dense
          >
            <v-timeline-item
              v-for="(message, index) in conversation.messages"
              :key="index"
              :color="message.color"
              small
            >
              <div>
                <div class="font-weight-normal">
                  <strong>{{ message.from }}</strong> @{{ message.time }}
                </div>
                <div class="message-content">{{ message.text }}</div>
              </div>
            </v-timeline-item>
          </v-timeline>
        </v-card-text>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
export default {
  props: {
    id: {
      type: Number,
      required: false
    },
    title: {
      type: String,
      required: false
    },
    prompt: {
      type: Object,
      required: false
    },
    messages: {
      type: Array,
      required: false
    },
    prompts: {
      type: Array,
      required: false
    }
  },
  data () {
    return {
      loading: false,
      conversation: {
        title: this.title,
        prompt: this.prompt,
        messages: this.messages?.map((m) => {
          return {
            from: m.fromAi ? 'Ai Assistant' : 'You',
            text: this.splitText(m.text.trim()),
            time: new Date(m.createdDate).toLocaleString(),
            color: m.fromAi ? 'green' : 'deep-purple lighten-1'
          }
        })
      },
      promptItems: this.prompts
    }
  },
  methods: {
    splitText (text) {
      return text.replace(/```csharp([\s\S]*)```/gm, '$1')
    },
    required (v) {
      return !!v || 'Field is required'
    },
    async submitForm () {
      const valid = await this.$refs.form.validate()

      if (!valid) { return }

      try {
        this.loading = true
        if (this.id) { await this.update() } else { await this.add() }
      } catch (e) {
        console.error(e)
      } finally {
        this.loading = false
      }
    },
    async add () {
      const payload = {
        title: this.conversation.title,
        promptId: this.conversation.prompt?.id
      }
      console.log('payload:', this.payload)
      await this.$axios.post('api/Conversations', payload)
        .then(() => {
          this.$router.push('/conversations')
        })
        .catch((error) => {
          console.error('error:', error)
        })
    },
    async update () {
      const payload = {
        title: this.conversation.title
      }
      await this.$axios.put('api/Conversations/' + this.id, payload)
        .then(() => {
          this.$router.push('/conversations')
        })
        .catch((error) => {
          console.error('error:', error)
        })
    }

  }
}
</script>

<style scoped>
  .message-content{
    white-space: pre-wrap;
  }
  .code {
    font-family: monospace;
  }
</style>
