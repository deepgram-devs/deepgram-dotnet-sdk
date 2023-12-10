﻿global using System.Collections.Concurrent;
global using System.Net.Http.Headers;
global using System.Net.WebSockets;
global using System.Reflection;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Text.RegularExpressions;
global using System.Threading.Channels;
global using System.Web;
global using Deepgram.Abstractions;
global using Deepgram.Constants;
global using Deepgram.DeepgramEventArgs;
global using Deepgram.Enums;
global using Deepgram.Logger;
global using Deepgram.Models;
global using Deepgram.Utilities;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Abstractions;
global using Polly;
global using Polly.Contrib.WaitAndRetry;
