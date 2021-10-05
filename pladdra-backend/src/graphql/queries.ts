/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const getWorkspace = /* GraphQL */ `
  query GetWorkspace($id: ID!) {
    getWorkspace(id: $id) {
      id
      name
      createdAt
      updatedAt
      description
      dialougeID
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
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
export const listWorkspaces = /* GraphQL */ `
  query ListWorkspaces(
    $filter: ModelWorkspaceFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listWorkspaces(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        name
        createdAt
        updatedAt
        description
        dialougeID
        usersCanWrite
        usersCanAccess
        groupsCanWrite
        groupsCanAccess
        blocks {
          nextToken
        }
        owner
      }
      nextToken
    }
  }
`;
export const getAsset = /* GraphQL */ `
  query GetAsset($id: ID!) {
    getAsset(id: $id) {
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
export const listAssets = /* GraphQL */ `
  query ListAssets(
    $filter: ModelAssetFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listAssets(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
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
      nextToken
    }
  }
`;
export const assetsByFileFormat = /* GraphQL */ `
  query AssetsByFileFormat(
    $fileFormat: AssetFileFormat
    $createdAtUpdatedAt: ModelAssetByFileFormatCompositeKeyConditionInput
    $sortDirection: ModelSortDirection
    $filter: ModelAssetFilterInput
    $limit: Int
    $nextToken: String
  ) {
    assetsByFileFormat(
      fileFormat: $fileFormat
      createdAtUpdatedAt: $createdAtUpdatedAt
      sortDirection: $sortDirection
      filter: $filter
      limit: $limit
      nextToken: $nextToken
    ) {
      items {
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
      nextToken
    }
  }
`;
export const getBlock = /* GraphQL */ `
  query GetBlock($id: ID!) {
    getBlock(id: $id) {
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
export const listBlocks = /* GraphQL */ `
  query ListBlocks(
    $filter: ModelBlockFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listBlocks(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
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
      nextToken
    }
  }
`;
export const getDialogue = /* GraphQL */ `
  query GetDialogue($id: ID!) {
    getDialogue(id: $id) {
      id
      name
      description
      status
      plannerArgs {
        workspace {
          initialScale
          minScale
          maxScale
          pinchToScale
        }
        block {
          collision
        }
        inventory {
          categories
          limitBy
          limitValue
        }
      }
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
      createdAt
      updatedAt
      owner
    }
  }
`;
export const listDialogues = /* GraphQL */ `
  query ListDialogues(
    $filter: ModelDialogueFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listDialogues(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        name
        description
        status
        usersCanWrite
        usersCanAccess
        groupsCanWrite
        groupsCanAccess
        createdAt
        updatedAt
        owner
      }
      nextToken
    }
  }
`;
export const getInventory = /* GraphQL */ `
  query GetInventory($id: ID!) {
    getInventory(id: $id) {
      id
      name
      dialougeID
      order
      createdAt
      updatedAt
      owner
    }
  }
`;
export const listInventorys = /* GraphQL */ `
  query ListInventorys(
    $filter: ModelInventoryFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listInventorys(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        name
        dialougeID
        order
        createdAt
        updatedAt
        owner
      }
      nextToken
    }
  }
`;
