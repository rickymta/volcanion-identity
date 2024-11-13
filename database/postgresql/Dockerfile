# Arguments
ARG POSTGRES_VERSION=16.4-alpine
ARG POSTGRES_USER=postgres
ARG POSTGRES_PASSWORD=postgres
ARG POSTGRES_DB=postgres

# Use the official PostgreSQL 16 image
FROM postgres:$POSTGRES_VERSION

# Set environment variables for PostgreSQL
# These environment variables will be used to create database, user and password for PostgreSQL
ENV POSTGRES_USER=$POSTGRES_USER
ENV POSTGRES_PASSWORD=$POSTGRES_PASSWORD
ENV POSTGRES_DB=$POSTGRES_DB

# Copy the SQL file to initialize the database if any
# If there is a SQL script to initialize the table or seed data, you can put it in the /docker-entrypoint-initdb.d/ directory
# Docker will automatically run the SQL files in this directory when initializing the container
# Example:
# COPY ./init.sql /docker-entrypoint-initdb.d/

# Expose default port of PostgreSQL
EXPOSE 5432
