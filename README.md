# Global Alert System

## Overview

The Global Alert System is a real-time emergency alerting platform that detects and notifies users about critical incidents such as accidents, natural disasters, and security threats and provision for dynamic incident creation for custom industry. It leverages .NET microservices, Kafka for communication, Azure services for cloud infrastructure, and machine learning models for prediction and analysis.

## Architecture

Key Components:

API Gateway: Acts as the central entry point for routing all incoming requests to microservices.

Kafka: Facilitates communication between microservices, ensuring efficient data flow.

## Microservices:

Incident Report Service: Collects and processes emergency incident data from various sources (IoT devices, external APIs, user reports).

User Catalog Service: Manages user profiles, preferences, and notification settings.

Notification System: Sends alerts via email, SMS, and push notifications.

Emergency Details Service: Provides additional information about incidents (location, severity, response guidance).

Prediction & Analysis Service: Uses Azure Machine Learning for risk assessment and event forecasting.

Azure Cosmos DB: Stores user data, incident records, and processed alerts.

Frontend Dashboard & Mobile App: Allows users to view incidents, manage alerts, and interact with the system.

# Technology Stack

Backend: .NET Core, Kafka, Azure Functions

Frontend: React (Next.js), Framer Motion, Three.js

Database: Azure Cosmos DB

Cloud Services: Azure Machine Learning, Azure Event Hub, Azure Service Bus

## Workflow

An incident is detected from IoT sensors, APIs, or user reports.

Data is ingested via the API Gateway and published to Kafka.

Microservices process the data and enrich it with additional details.

The Prediction Service evaluates the severity and impact using machine learning.

The Notification System sends real-time alerts to users based on location and preferences.

Users receive alerts via email, SMS, or mobile push notifications.

The Frontend Dashboard provides an interactive UI for monitoring events.

## Deployment

The system is deployed using Azure Kubernetes Service (AKS) with CI/CD pipelines integrated for automated updates.

Future Enhancements

Implement AI-based incident classification.

Add geospatial analytics for better real-time tracking.

Enhance mobile app functionalities for user reporting and feedback.

## license 
Sachin Rampur





