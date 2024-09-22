using Confluent.Kafka;

namespace Messaging.Kafka;

public class Test
{
    public void Yeet()
    {
        var config = new ClientConfig();
        
        var consumer = new ConsumerBuilder<Null, string>(config).Build();

        var result = consumer.Consume();

        var ye = result.Topic;
    }
}
