namespace ProductsServer
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    public class ProductsContract
    {
        [DataContract]
        public class ProductData
        {
            [DataMember]
            public string Id { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Quantity { get; set; }
        }

        [ServiceContract]
        public interface IProducts
        {
            [OperationContract]
            IList<ProductData> GetProducts();

        }

        public interface IProductsChannel : IProducts, IClientChannel
        {
        }
    }
}
