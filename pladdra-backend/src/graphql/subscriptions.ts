/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const onCreateAsset = /* GraphQL */ `
  subscription OnCreateAsset {
    onCreateAsset {
      id
      name
      type
      fileFormat
      fileName
      fileSize
      file {
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
      name
      type
      fileFormat
      fileName
      fileSize
      file {
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
      name
      type
      fileFormat
      fileName
      fileSize
      file {
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
export const onCreateBlock = /* GraphQL */ `
  subscription OnCreateBlock($owner: String) {
    onCreateBlock(owner: $owner) {
      id
      createdAt
      updatedAt
      workspaceID
      assetID
      position {
        x
        y
        z
      }
      rotation {
        x
        y
        z
        w
      }
      owner
    }
  }
`;
export const onUpdateBlock = /* GraphQL */ `
  subscription OnUpdateBlock($owner: String) {
    onUpdateBlock(owner: $owner) {
      id
      createdAt
      updatedAt
      workspaceID
      assetID
      position {
        x
        y
        z
      }
      rotation {
        x
        y
        z
        w
      }
      owner
    }
  }
`;
export const onDeleteBlock = /* GraphQL */ `
  subscription OnDeleteBlock($owner: String) {
    onDeleteBlock(owner: $owner) {
      id
      createdAt
      updatedAt
      workspaceID
      assetID
      position {
        x
        y
        z
      }
      rotation {
        x
        y
        z
        w
      }
      owner
    }
  }
`;
export const onCreateWorkspace = /* GraphQL */ `
  subscription OnCreateWorkspace($owner: String) {
    onCreateWorkspace(owner: $owner) {
      id
      name
      createdAt
      updatedAt
      description
      blocks {
        items {
          id
          createdAt
          updatedAt
          workspaceID
          assetID
          owner
        }
        nextToken
      }
      owner
    }
  }
`;
export const onUpdateWorkspace = /* GraphQL */ `
  subscription OnUpdateWorkspace($owner: String) {
    onUpdateWorkspace(owner: $owner) {
      id
      name
      createdAt
      updatedAt
      description
      blocks {
        items {
          id
          createdAt
          updatedAt
          workspaceID
          assetID
          owner
        }
        nextToken
      }
      owner
    }
  }
`;
export const onDeleteWorkspace = /* GraphQL */ `
  subscription OnDeleteWorkspace($owner: String) {
    onDeleteWorkspace(owner: $owner) {
      id
      name
      createdAt
      updatedAt
      description
      blocks {
        items {
          id
          createdAt
          updatedAt
          workspaceID
          assetID
          owner
        }
        nextToken
      }
      owner
    }
  }
`;
