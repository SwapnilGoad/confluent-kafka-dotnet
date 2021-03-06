// Copyright 2016-2018 Confluent Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Refer to LICENSE for more information.

using System;
using System.Net;


namespace Confluent.SchemaRegistry
{
    /// <summary>
    ///     Represents an error returned by Confluent Schema Registry.
    /// </summary>
    public class SchemaRegistryException : Exception
    {
        /// <summary>
        ///     An error code specfic to Schema Registry of the form XXX or XXXYY.
        ///     where XXX is standard http error status (400-500) and YY specific to schema registry
        ///     Example: 40403 = Schema not found
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        ///     Standard HTTP response code.
        /// </summary>
        public HttpStatusCode Status { get; }

        /// <summary>
        ///     Initialize a new instance of SchemaRegistryException.
        /// </summary>
        /// <param name="message">
        ///     Additional information about the error.
        /// </param>
        /// <param name="status">
        ///     The HTTP Status Code.
        /// </param>
        /// <param name="errorCode">
        ///     The Confluent Schema Registry error code.
        /// </param>
        public SchemaRegistryException(string message, HttpStatusCode status, int errorCode)
            : base(message + "; error code: " + errorCode)
        {
            ErrorCode = errorCode;
            Status = status;
        }
    }
}
