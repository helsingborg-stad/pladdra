using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Net.Http;


using System.Threading;
using GraphQL.Client.Abstractions;

namespace Pladdra.API
{
    public class GraphQLClient : MonoBehaviour
    {

        private static GraphQLClient s_instance;

        [SerializeField] private string appSyncApiUrl;
        [SerializeField] private string appSyncApiKey;
        [SerializeField] private string appSyncApiID;

        public static GraphQLHttpClient client;

        public static Task<GraphQLResponse<TResponse>> SendQueryAsync<TResponse>(GraphQLRequest request, CancellationToken cancellationToken = default) => client.SendQueryAsync<TResponse>(request, cancellationToken);


        public static Task<GraphQLResponse<T>> Request<T>(string completeQueryString)
        {
            var request = new GraphQLRequest
            {
                Query = completeQueryString
            };

            return client.SendQueryAsync<T>(request);
        }

        private GraphQLHttpClient Connect()
        {
            Uri uri = new Uri(appSyncApiUrl);
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = uri,
                PreprocessRequest = this.PreprocessRequest
            };

            return new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
        }

        private Task<GraphQLHttpRequest> PreprocessRequest(GraphQLRequest request, GraphQLHttpClient client)
        {

            if (!client.HttpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                client.HttpClient.DefaultRequestHeaders.Add("x-api-key", appSyncApiKey);
            }

            return Task.FromResult(new GraphQLHttpRequest(request));
        }

        private void Awake()
        {
            s_instance = this;
            client = Connect();
        }
    }
}