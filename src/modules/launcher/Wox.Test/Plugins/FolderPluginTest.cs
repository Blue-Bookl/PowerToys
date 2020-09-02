﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.Plugin.Folder;
using Moq;
using NUnit.Framework;
using Wox.Plugin;

namespace Wox.Test.Plugins
{
    internal class FolderPluginTest
    {
        [Test]
        public void ContextMenuLoader_ReturnContextMenuForFolderWithOpenInConsole_WhenLoadContextMenusIsCalled()
        {
            // Arrange
            var mock = new Mock<IPublicAPI>();
            var pluginInitContext = new PluginInitContext() { API = mock.Object };
            var contextMenuLoader = new ContextMenuLoader(pluginInitContext);
            var searchResult = new SearchResult() { Type = ResultType.Folder, FullPath = "C:/DummyFolder" };
            var result = new Result() { ContextData = searchResult };

            // Act
            List<ContextMenuResult> contextMenuResults = contextMenuLoader.LoadContextMenus(result);

            // Assert
            Assert.AreEqual(contextMenuResults.Count, 2);
            Assert.AreEqual(contextMenuResults[0].Title, Microsoft.Plugin.Folder.Properties.Resources.Microsoft_plugin_folder_copy_path);
            Assert.AreEqual(contextMenuResults[1].Title, Microsoft.Plugin.Folder.Properties.Resources.Microsoft_plugin_folder_open_in_console);
        }

        [Test]
        public void ContextMenuLoader_ReturnContextMenuForFileWithOpenInConsole_WhenLoadContextMenusIsCalled()
        {
            // Arrange
            var mock = new Mock<IPublicAPI>();
            var pluginInitContext = new PluginInitContext() { API = mock.Object };
            var contextMenuLoader = new ContextMenuLoader(pluginInitContext);
            var searchResult = new SearchResult() { Type = ResultType.File, FullPath = "C:/DummyFile.cs" };
            var result = new Result() { ContextData = searchResult };

            // Act
            List<ContextMenuResult> contextMenuResults = contextMenuLoader.LoadContextMenus(result);

            // Assert
            Assert.AreEqual(contextMenuResults.Count, 3);
            Assert.AreEqual(contextMenuResults[0].Title, Microsoft.Plugin.Folder.Properties.Resources.Microsoft_plugin_folder_open_containing_folder);
            Assert.AreEqual(contextMenuResults[1].Title, Microsoft.Plugin.Folder.Properties.Resources.Microsoft_plugin_folder_copy_path);
            Assert.AreEqual(contextMenuResults[2].Title, Microsoft.Plugin.Folder.Properties.Resources.Microsoft_plugin_folder_open_in_console);
        }
    }
}
