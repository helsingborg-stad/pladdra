/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const createAsset = /* GraphQL */ `
  mutation CreateAsset(
    $input: CreateAssetInput!
    $condition: ModelAssetConditionInput
  ) {
    createAsset(input: $input, condition: $condition) {
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
export const updateAsset = /* GraphQL */ `
  mutation UpdateAsset(
    $input: UpdateAssetInput!
    $condition: ModelAssetConditionInput
  ) {
    updateAsset(input: $input, condition: $condition) {
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
export const deleteAsset = /* GraphQL */ `
  mutation DeleteAsset(
    $input: DeleteAssetInput!
    $condition: ModelAssetConditionInput
  ) {
    deleteAsset(input: $input, condition: $condition) {
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
export const createWorkspace = /* GraphQL */ `
  mutation CreateWorkspace(
    $input: CreateWorkspaceInput!
    $condition: ModelWorkspaceConditionInput
  ) {
    createWorkspace(input: $input, condition: $condition) {
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
export const updateWorkspace = /* GraphQL */ `
  mutation UpdateWorkspace(
    $input: UpdateWorkspaceInput!
    $condition: ModelWorkspaceConditionInput
  ) {
    updateWorkspace(input: $input, condition: $condition) {
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
export const deleteWorkspace = /* GraphQL */ `
  mutation DeleteWorkspace(
    $input: DeleteWorkspaceInput!
    $condition: ModelWorkspaceConditionInput
  ) {
    deleteWorkspace(input: $input, condition: $condition) {
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
export const createBlock = /* GraphQL */ `
  mutation CreateBlock(
    $input: CreateBlockInput!
    $condition: ModelBlockConditionInput
  ) {
    createBlock(input: $input, condition: $condition) {
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
export const updateBlock = /* GraphQL */ `
  mutation UpdateBlock(
    $input: UpdateBlockInput!
    $condition: ModelBlockConditionInput
  ) {
    updateBlock(input: $input, condition: $condition) {
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
export const deleteBlock = /* GraphQL */ `
  mutation DeleteBlock(
    $input: DeleteBlockInput!
    $condition: ModelBlockConditionInput
  ) {
    deleteBlock(input: $input, condition: $condition) {
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
export const createDialogue = /* GraphQL */ `
  mutation CreateDialogue(
    $input: CreateDialogueInput!
    $condition: ModelDialogueConditionInput
  ) {
    createDialogue(input: $input, condition: $condition) {
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
export const updateDialogue = /* GraphQL */ `
  mutation UpdateDialogue(
    $input: UpdateDialogueInput!
    $condition: ModelDialogueConditionInput
  ) {
    updateDialogue(input: $input, condition: $condition) {
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
export const deleteDialogue = /* GraphQL */ `
  mutation DeleteDialogue(
    $input: DeleteDialogueInput!
    $condition: ModelDialogueConditionInput
  ) {
    deleteDialogue(input: $input, condition: $condition) {
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
export const createInventory = /* GraphQL */ `
  mutation CreateInventory(
    $input: CreateInventoryInput!
    $condition: ModelInventoryConditionInput
  ) {
    createInventory(input: $input, condition: $condition) {
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
export const updateInventory = /* GraphQL */ `
  mutation UpdateInventory(
    $input: UpdateInventoryInput!
    $condition: ModelInventoryConditionInput
  ) {
    updateInventory(input: $input, condition: $condition) {
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
export const deleteInventory = /* GraphQL */ `
  mutation DeleteInventory(
    $input: DeleteInventoryInput!
    $condition: ModelInventoryConditionInput
  ) {
    deleteInventory(input: $input, condition: $condition) {
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
