using INN_client;

DadataClient client = new DadataClient();

client.connectViaDadataApi().Wait();
client.connectViaHttpClient().Wait();