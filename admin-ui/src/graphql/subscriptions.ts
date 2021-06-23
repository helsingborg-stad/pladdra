/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const onCreateAsset = /* GraphQL */ `
  subscription OnCreateAsset {
    onCreateAsset {
      id
      title
      type
      format
      source {
        bucket
        key
        region
      }
      description
      createdAt
      updatedAt
    }
  }
`;
export const onUpdateAsset = /* GraphQL */ `
  subscription OnUpdateAsset {
    onUpdateAsset {
      id
      title
      type
      format
      source {
        bucket
        key
        region
      }
      description
      createdAt
      updatedAt
    }
  }
`;
export const onDeleteAsset = /* GraphQL */ `
  subscription OnDeleteAsset {
    onDeleteAsset {
      id
      title
      type
      format
      source {
        bucket
        key
        region
      }
      description
      createdAt
      updatedAt
    }
  }
`;
export const onCreateTodo = /* GraphQL */ `
  subscription OnCreateTodo($owner: String!) {
    onCreateTodo(owner: $owner) {
      id
      name
      description
      image {
        bucket
        key
        region
      }
      createdAt
      updatedAt
      owner
    }
  }
`;
export const onUpdateTodo = /* GraphQL */ `
  subscription OnUpdateTodo($owner: String!) {
    onUpdateTodo(owner: $owner) {
      id
      name
      description
      image {
        bucket
        key
        region
      }
      createdAt
      updatedAt
      owner
    }
  }
`;
export const onDeleteTodo = /* GraphQL */ `
  subscription OnDeleteTodo($owner: String!) {
    onDeleteTodo(owner: $owner) {
      id
      name
      description
      image {
        bucket
        key
        region
      }
      createdAt
      updatedAt
      owner
    }
  }
`;
