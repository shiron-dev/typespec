// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace UnbrandedTypeSpec.Models
{
    public partial class Thing : System.ClientModel.Primitives.IJsonModel<Thing>
    {
        private IDictionary<string, System.BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Thing"/>. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="requiredUnion"> required Union. </param>
        /// <param name="requiredLiteralString"> required literal string. </param>
        /// <param name="requiredLiteralInt"> required literal int. </param>
        /// <param name="requiredLiteralFloat"> required literal float. </param>
        /// <param name="requiredLiteralBool"> required literal bool. </param>
        /// <param name="optionalLiteralString"> optional literal string. </param>
        /// <param name="optionalLiteralInt"> optional literal int. </param>
        /// <param name="optionalLiteralFloat"> optional literal float. </param>
        /// <param name="optionalLiteralBool"> optional literal bool. </param>
        /// <param name="requiredBadDescription"> description with xml <|endoftext|>. </param>
        /// <param name="optionalNullableList"> optional nullable collection. </param>
        /// <param name="requiredNullableList"> required nullable collection. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Thing(string name, System.BinaryData requiredUnion, ThingRequiredLiteralString requiredLiteralString, ThingRequiredLiteralInt requiredLiteralInt, ThingRequiredLiteralFloat requiredLiteralFloat, bool requiredLiteralBool, ThingOptionalLiteralString optionalLiteralString, ThingOptionalLiteralInt optionalLiteralInt, ThingOptionalLiteralFloat optionalLiteralFloat, bool optionalLiteralBool, string requiredBadDescription, IList<int> optionalNullableList, IList<int> requiredNullableList, IDictionary<string, System.BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            RequiredUnion = requiredUnion;
            RequiredLiteralString = requiredLiteralString;
            RequiredLiteralInt = requiredLiteralInt;
            RequiredLiteralFloat = requiredLiteralFloat;
            RequiredLiteralBool = requiredLiteralBool;
            OptionalLiteralString = optionalLiteralString;
            OptionalLiteralInt = optionalLiteralInt;
            OptionalLiteralFloat = optionalLiteralFloat;
            OptionalLiteralBool = optionalLiteralBool;
            RequiredBadDescription = requiredBadDescription;
            OptionalNullableList = optionalNullableList;
            RequiredNullableList = requiredNullableList;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Thing"/> for deserialization. </summary>
        internal Thing()
        {
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void System.ClientModel.Primitives.IJsonModel<Thing>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        Thing System.ClientModel.Primitives.IJsonModel<Thing>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            return new Thing();
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Thing>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            return new System.BinaryData("IPersistableModel");
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        Thing System.ClientModel.Primitives.IPersistableModel<Thing>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            return new Thing();
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        string System.ClientModel.Primitives.IPersistableModel<Thing>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) => "J";
    }
}
