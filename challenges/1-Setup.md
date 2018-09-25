# Lab 1 - Setup

## Prerequisities

1. Azure Subscription (Trial, Visual Studio B enefits, or Internal Use)

## Introduction

This lab will help you get your development environment setup. This will include getting all the required software installed, getting a copy of the source code, and finally building and running the solution locally.

## Challenges

> NOTE: Here we will be building the development environment from the ground up using a Windows VM in Azure and Visual Studio Code. Please note you can install/run everything locally on just about any operating system or use the full Visual Studio IDE, however the process might be a bit different and setup might take longer.

1. Create a VM in Azure
   1. Create a VM using the "Visual Studio Community 2017 on Windows Server 2016 (x64)" image
   1. Ensure you pick a VM compatible with virtualization (see:  [Nested Virtualization in Azure](https://azure.microsoft.com/en-us/blog/nested-virtualization-in-azure/))
   1. Ensure you enable Auto-Shutdown
   1. Ensure you open the port for RDP
   1. Use the VM you created for the following steps.
1. Install Docker Community Edition ([Windows](https://docs.docker.com/docker-for-windows/install/), [Mac](https://docs.docker.com/docker-for-mac/install/))
   1. You can used either lunix or windows containers
   1. The installer will promt you to log out and then back in, and then prompt you that it will reboot your vm.
1. Install [.NET Core SDK 2.0](https://www.microsoft.com/net/core)
1. Get a GitHub account, if you don't already have one.
1. Fork this repo into your GitHub account
1. Clone your fork of the repo locally
   1. HINT: the VM has the Git tools already installed on it
1. Open the RockPaperScissorsBoom folder in VS Code
1. Run the RockPaperScissorsBoom.Server application
   1. HINT: use the dotnet run command and the intergrated terminal in VS Code

## Resources

1. [Your current security settings do not allow this file to be downloaded](https://answers.microsoft.com/en-us/ie/forum/ie8-windows_other/error-message-your-current-security-settings-do/59cc236d-7baf-4552-92ff-b34b9a6942aa)
1. [Docker Basics with .NET Core](https://docs.microsoft.com/en-us/dotnet/core/docker/docker-basics-dotnet-core)
